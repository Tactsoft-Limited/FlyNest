using Microsoft.AspNetCore.Http;
using Nancy.Json;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace FlyNest.SharedKernel.Core.PaymentGateway;

public class SSLCommerzGateway
{
    public class SSLCommerzInitRes
    {
        public string status { get; set; }
        public string failedreason { get; set; }
        public string sessionkey { get; set; }
        public Gw gw { get; set; }
        public string redirectGatewayURL { get; set; }
        public string redirectGatewayURLFailed { get; set; }
        public string GatewayPageURL { get; set; }
        public string storeBanner { get; set; }
        public string storeLogo { get; set; }
        public List<Desc> desc { get; set; }
        public string is_direct_pay_enable { get; set; }
    }

    public class Gw
    {
        public string visa { get; set; }
        public string master { get; set; }
        public string amex { get; set; }
        public string othercards { get; set; }
        public string internetbanking { get; set; }
        public string mobilebanking { get; set; }
    }

    public class Desc
    {
        public string name { get; set; }
        public string type { get; set; }
        public string logo { get; set; }
        public string gw { get; set; }
    }

    public class SSLCommerzSetting
    {
        public string StoreId { get; set; }
        public string StoreSecret { get; set; }
        public string AppUrl { get; set; }
    }

}
