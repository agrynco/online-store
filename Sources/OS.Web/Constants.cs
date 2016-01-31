﻿namespace OS.Web
{
    public static class Constants
    {
        public static class TempDataKeys
        {
            public const string PRODUCT_CATEGORIES_FILTER_VIEW_MODEL = "ProductCategoriesFilterViewModel";
            public const string PRODUCTS_FILTER_VIEW_MODEL = "{FBD2BEDF-4AF9-458F-A949-ECA0EC98E72C}";
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
    }
}