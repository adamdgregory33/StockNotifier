StockNotifier

A REST API to take a given set of information for a trade (broker, ticker, volume, cost), store the information and notify interested parties of current price of the traded ticker.

System design: Thin Application that services endpoints using clients/ repositories directly from controllers. Swagger for API docs in dev.

Enhancements:
System design - Something to orchestrate business logic other than controller - reponsible for exception management to return to controller appropriate responses. (KISS/YAGNI for now)
Scaling - containers with scaling policies; Could work well with serverless, specifically aws lambdas / azure functions depending on load since logic is quite small

NFRs - Security - WAF for attacks, proper request validation, authentication/authorization (whatever company has already), PII considerations (no PII in this case), certificates, CORS policies
Mainatainability - Unit test coverage, integration tests, potential E2E tests integrated with other systems in an env, Load tests (e.g locust). Documentation. Staging for API versioning.
Performance - Optimise models (could potentially use records, more strict on get; set;).
				Async optimisation (not much for there to optimise at this point). Storage choice (e.g nosql dynamo / cosmos) & caching.
Usability - Align Endpoint conventions with any wider approach used for consistency. API Docs.

Code:
BrokerID could as a GUID
Ticker - Use ENUM / fetch from a table/client and cache the names (depending how many tickers)
Validation on Broker & Ticker
