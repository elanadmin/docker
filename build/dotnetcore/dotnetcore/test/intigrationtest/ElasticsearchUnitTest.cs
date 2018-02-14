using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using HostApi.Model;
using Nest;
using System.Diagnostics;

namespace intigrationtest
{
    
    public class ElasticsearchUnitTest
    {
        private const string ConnectionString = "http://localhost:9200/";
        private ElasticClient client;
       
       public ElasticsearchUnitTest()
       {
           var node = new Uri(ConnectionString);
           var setting = new ConnectionSettings(node);
           setting.BasicAuthentication("ganesh","ganesh");

           client = new ElasticClient(setting);
       }

       [Fact]
       [Trait("Category","es")]
       public void Elasticsearch_Indexing_Test()
       {
            var obj = new Product{
                Name = "Test",
                Category = "Test Category"
            };

            Console.WriteLine("Creating index....");
            
            var response = client.Index(obj, idx=> idx.Index("dotnetelasticsample"));

            Console.WriteLine(response.DebugInformation);

            Assert.NotNull(response.Id);
            Trace.Write(response);
       }

       [Fact]
       public void Search_Product_Test()
       {
           var searchResult = client.Search<Product>(s=>s
                        .Index("dotnetelasticsample")   // if no default index provider
                        .From(0)
                        .Size(10)
                        );
            
            Assert.NotEqual(0, searchResult.Hits.Count);
            Console.WriteLine(searchResult.DebugInformation);
       }
 

    }
}