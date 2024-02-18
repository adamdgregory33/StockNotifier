using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using StockNotifier.src.Clients.Downstream;

namespace StockNotifier.Test.Unit.Controller
{
    public class InMemoryTickerInfoClientTests
    {
        private readonly InMemoryTickerInforClient _client;
        private readonly IFixture _fixture;

        public InMemoryTickerInfoClientTests()
        {
            _client = new InMemoryTickerInforClient();
            _fixture = new Fixture();
        }

    }
}