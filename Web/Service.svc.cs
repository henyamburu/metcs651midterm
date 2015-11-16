using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using Web.Models;

namespace Web
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service
    {      
        [WebGet]
        [OperationContract]
        public string GetMessage(string encodedMessage, string method)
        {
            if (!string.IsNullOrWhiteSpace(encodedMessage) &&
                !string.IsNullOrWhiteSpace(method))
            {
                method = method.ToLower();
                Strategy strategy = null;
                switch (method)
                {
                    case "cryptogram":
                        strategy = new Cryptogram();
                        break;
                    case "bigram":
                        strategy = new Bigram();
                        break;
                    case "monogram":
                        strategy = new Monogram();
                        break;
                    case "trigram":
                        strategy = new Trigram();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("typeName", "Type name value is not defined");
                }

                return strategy.Decode(encodedMessage);
            }

            return string.Empty;            
        }
    }
}
