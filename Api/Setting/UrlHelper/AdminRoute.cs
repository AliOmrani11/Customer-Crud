namespace Player.Presentation.Setting.UrlHelper;

public static class AdminRoute
{
    public const string BaseUrl = "api/v{version:apiversion}/";
    public static class Customer
    {
        public const string Insert = BaseUrl + "customer/insert";
        public const string Delete = BaseUrl + "customer/delete";
        public const string GetAll = BaseUrl + "customer/get-all";
        public const string Get = BaseUrl + "customer/get";
        public const string Update = BaseUrl + "customer/update";
    }
}
