using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;
using SpotifyWebHelperAPI.Models;
using SpotifyWebHelperAPI.Serialization;
using SpotifyWebHelperAPI.Web;

namespace SpotifyWebHelperAPI.UnitTests
{
    [TestClass]
    public class SpotifyWebHelperCommunicationServiceTests
    {
        [TestMethod]
        public void GivenThatVersionDataIsReturned_WhenGetStatusIsCalled_ThenTheReturnedStatusDtoContainsTheCorrectVersion()
        {
            var authProvider = MockRepository.GenerateMock<IAuthProvider>();
            authProvider.Stub(x => x.GetAuth()).Return("ourAuth");
            authProvider.Stub(x => x.GetCFID()).Return(new CFIDDto { Token = "ourCfid" });

            var webClient = MockRepository.GenerateMock<IRequestService>();
            webClient.Stub(x => x.SendRequest(Arg<string>.Is.Anything, Arg<string>.Matches(Text.Contains("ourAuth")), Arg<string>.Matches(Text.Contains("ourCfid")))).Return("123456");

            var deserializer = MockRepository.GenerateMock<IDeserializer>();
            deserializer.Stub(x => x.DeserializeObject<StatusDto>(Arg<string>.Is.Equal("123456"))).Return(new StatusDto() { Version = 123456 });

            var service = new SpotifyWebHelperCommunicationService(webClient, deserializer, "ourAuth", "ourCfid");

            var status = service.GetStatus();

            Assert.AreEqual(123456, status.Version);
        }
    }
}