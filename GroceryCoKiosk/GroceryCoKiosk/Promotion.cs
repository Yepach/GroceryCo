using System;

namespace GroceryCoKiosk
{

    public abstract class Promotion
    {
        public double _Discount { get; set; }
        public int _RequiredCount { get; set; }
        public int _Occurences { get; set; }

        public Promotion(double Discount, int RequiredCount)
        {
            _Discount = Discount;
            _RequiredCount = RequiredCount;
        }

        public virtual double CalculatedDiscountedPrice(double Price)
        {
            // If the discount requirements are met, returns the items new price otherwise regular price
            _Occurences++;
            if (QuantityRequirementsMet(_Occurences))
            {
                return _Discount;
            }
            return Price;
        }

        public virtual bool QuantityRequirementsMet(int occurences)
        {
            // Returns true if the necessary amount of items are being purchased 
            try
            {
                if (occurences % _RequiredCount == 0)
                {
                    return true;
                }
            }
            catch(DivideByZeroException)
            {
                ErrorHandling.DisplyError("Divided by 0");
            }
            return false;
        }
        
    }

    public class OnSalePromotion : Promotion
    {
        // selected products are purchased at a discounted price which is less then regular price.      
        public OnSalePromotion(double Discount) : base(Discount, 1) { }
        static public OnSalePromotion CreateOnSalePromotion(String Discount)
        {
            // Parse the discount from the string parameters
            double d;
            if (!double.TryParse(Discount, out d))
            {
                ErrorHandling.DisplyError("Failed to parse discount (double) from: " + Discount);
                return null;
            }
            return new OnSalePromotion(d);
        }

    }

    public class GroupPromotion : Promotion
    {
        // Products purchased which reach a specified quantity have a discounted price.
        public GroupPromotion(double Discount, int RequiredCount) : base(Discount, RequiredCount) { }

        static public GroupPromotion CreateGroupPromotion(String Discount, String RequiredCount)
        {
            // Parse the discount from the string parameters
            double d;
            if (!double.TryParse(Discount, out d))
            {
                ErrorHandling.DisplyError("Failed to parse discount (double) from: " + Discount);
                return null;
            }

            // Parse the RequiredCount from the string parameters
            int i;
            if (!int.TryParse(RequiredCount, out i))
            {
                ErrorHandling.DisplyError("Failed to parse required count (int) from: " + RequiredCount);
                return null;
            }

            return new GroupPromotion(d,i);
        }

        public override double CalculatedDiscountedPrice(double Price)
        {
            // Returns how much the last item in the group should cost to maintain the promotion
            _Occurences++;
            if (QuantityRequirementsMet(_Occurences))
            {
                return Price - (_RequiredCount*Price - _Discount);
            }
            return Price;
        }
    }

    public class AdditionalProductDiscount : Promotion
    {
        // Products purchased which reach a speciified quantity will discount an additional product of the same kind.
        public AdditionalProductDiscount(double Discount) : base(Discount, 2) { }
               
        static public AdditionalProductDiscount CreatAdditionalProductDiscount(String Discount)
        {
            // Parse the discount from the string parameters
            double d;
            if (!double.TryParse(Discount, out d))
            {
                ErrorHandling.DisplyError("Failed to parse discount (double) from: " + Discount);
                return null;
            }
            return new AdditionalProductDiscount(d);
            
        }

    }

    public class Factory
    {
        public static Promotion PromotionFactory(String PromotionType)
        {
            // Create the correct promotion from the given file
            PromotionType = PromotionType.ToLower();
            String[] seperator = { "/"};
            String[] elements = PromotionType.Split(seperator, StringSplitOptions.RemoveEmptyEntries);

            switch (elements[0].ToLower())
            {
                case "onsale":
                    return OnSalePromotion.CreateOnSalePromotion(elements[1]);

                case "group":
                    return GroupPromotion.CreateGroupPromotion(elements[1], elements[2]);

                case "additional":
                    return AdditionalProductDiscount.CreatAdditionalProductDiscount(elements[1]);

            }
            return null;
        }
    }

}
