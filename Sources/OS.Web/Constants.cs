namespace OS.Web
{
    public static class Constants
    {
        public static class TempDataKeys
        {
            public const string PRODUCT_CATEGORIES_PARENT_ID = "{AA8243D6-A3AB-4ECD-A584-5A5AF6F11527}";
            public const string PRODUCTS_FILTER_VIEW_MODEL = "{FBD2BEDF-4AF9-458F-A949-ECA0EC98E72C}";
            public const string ORDER_ID = "{2B1D1171-F82E-4753-B4CC-A593D3FE70D2}";
        }

        public static class RouteDataKeys
        {
            public const string CONTROLLER = "controller";
        }

        public static class Views
        {
            public static class Sections
            {
                public const string TOP_SECTION = "topSection";
            }
        }

        public static class PageData
        {
            public const string PAGE_TITLE = "PageTitle";
            public const string CREATE_ARGUMENTS = "CreateArguments";
            public const string SAVE_ACTION_NAME = "SaveActionName";
        }

        public static class RegularExpressions 
        {
            public const string EMAIL = "(?:[a-z0-9!#$%&\'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&\'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])";
        }
    }
}