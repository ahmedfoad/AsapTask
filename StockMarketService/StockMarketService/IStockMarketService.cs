using StockMarketService.Model;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

namespace StockMarketService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStockMarketService" in both code and config file together.
    [ServiceContract]
    public interface IStockMarketService
    {

        [OperationContract]
        Task<PolygonDataDto> FetchMarketStockDataAsync();

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
