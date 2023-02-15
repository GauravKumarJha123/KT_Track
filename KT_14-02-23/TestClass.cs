using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;

namespace KT_14_02_23
{
    
    public class TestClass
    {
        public string localHostURL = "http://localhost:3000/";

        //[Parallelizable(ParallelScope.All)]
        [TestCase(14, "Ice and Fire", "G martin"), Order(1)]

        public void CreatePost(int id , string title , string author)
        {
            RestClient restClient = new RestClient(localHostURL);
            RestRequest req = new RestRequest("posts"  , Method.Post);
            //req.AddQueryParameter("id", id);
            req.AddHeader("Accept", "*/*");
            req.RequestFormat = DataFormat.Json;
            string body = CreatePostRequestBody(id, title, author);
            req.AddBody(body);
            var response = restClient.Execute(req);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            string responseContent = response.Content;
            var responseInCorrectFormat =
                JsonConvert
                .DeserializeObject
                <CreatePostValidRequest>
                (responseContent);
            Assert.AreEqual(id, responseInCorrectFormat.id);
            Assert.AreEqual(title, responseInCorrectFormat.title);
            Assert.AreEqual(author, responseInCorrectFormat.author);
        }

        
        [TestCase(14, "Ice and Fire", "G martin"), Order(2)]
        public void RetrievePost(int id, string title, string author)
        {
            RestClient restClient = new RestClient(localHostURL);
            RestRequest req = new RestRequest("posts", Method.Get);
            //req.AddParameter("id", id);
            req.AddHeader("Accept", "*/*");
            Console.WriteLine(req.ToString());
            var response = restClient.Execute(req);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            string responseContent = response.Content;

            var responseInCorrectFormat =
                JsonConvert
                .DeserializeObject
                <RetrievePostValidResponse[]>
                (responseContent);

            Assert.AreEqual(title, responseInCorrectFormat[7].title);
            Assert.AreEqual(author, responseInCorrectFormat[7].author);

        }

        [TestCase(14, "Ice and Fire", "G martin") , Order(3)]
        public void UpdatePost(int id, string title, string author)
        {
            RestClient restClient = new RestClient(localHostURL);
            RestRequest req = new RestRequest("posts/" + id.ToString() , Method.Put);
            req.AddHeader("Accept", "*/*");
            req.RequestFormat = DataFormat.Json;
            string body = UpdatePostRequestBody(id, title, author);
            req.AddBody(body);

            var response = restClient.Execute(req);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            string responseContent = response.Content;

            var responseInCorrectFormat =
                JsonConvert
                .DeserializeObject
                <UpdatePostValidResponse>
                (responseContent);
            Assert.AreEqual(title, responseInCorrectFormat.title);
            Assert.AreEqual(author, responseInCorrectFormat.author);

        }

        [TestCase(14, "Ice and Fire", "G martin"), Order(4)]
        public void DeletePost(int id, string title, string author)
        {
            RestClient restClient = new RestClient(localHostURL);
            RestRequest req = new RestRequest("posts/" + id.ToString() , Method.Delete);
            req.AddHeader("Accept", "*/*");

            var response = restClient.Execute(req);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        private string UpdatePostRequestBody(int id, string title, string author)
        {
            UpdatePostValidResponse updatePostValidRequest = new UpdatePostValidResponse();
            updatePostValidRequest.id = id;
            updatePostValidRequest.title = title;
            updatePostValidRequest.author = author;
            return JsonConvert.SerializeObject(updatePostValidRequest);
        }

        private string CreatePostRequestBody(int id, string title, string author)
        {
            CreatePostValidRequest createPostValidRequest = new CreatePostValidRequest();
            createPostValidRequest.id = id;
            createPostValidRequest.title = title;
            createPostValidRequest.author = author;
            return JsonConvert.SerializeObject(createPostValidRequest);
        }
    }
}