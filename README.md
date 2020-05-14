# ButterflyCalc
## Structure
Project structure:
* ButterflyCalc.Api - the API that can be called to get a calculator result
* ButterflyCalc.Web - website written in ASP.NET MVC with a little bit of Vue.js too to show how a website would use the API. Note: the website is just for exercising the calculator, it is not production ready (e.g. vue.js is referenced via CDN in script tags instead of being installed as npm package)
* ButterflyCalc.Tests - unit tests for the API controller and service
* ButterflyCalc.Biz - CaclulatorService lives here, so that business logic is separated into it's own project
* ButterflyCalc.Common - I tend to put Dtos here as so many of the layers in a tiered solution used them, so that project references don't get cross-referenced

There are two main parts to the calculator itself:
* The CalculatorController - this is the WebAPI that can be called by clients (websites / console apps / other APIs) to get a calculation
* The CalculatorService - CalculatorController calls this service to perform the calculation - this is where the actual calculation is performed

## Logging
The calculator uses Serilog to log operations to a text file in the root directory of the API. I would normally put this not in the root directory of the API, as logs would get destroyed when the next verion of the API is released again, this should be revisited for actual logging location once we know where the API is being deployed. Or we might want to log to a database etc.

Also it is currently pretty verbose and we might want to revisit this before releasing to production.

## Validation
I did put some validation in around exceeding decimal max and min (see unit tests) and division by zero but would like to ask the business / product owner / business analyst if there is anything I have not considered.

This might be a good starting point for discussions:
https://www.bayesserver.com/Techniques/NumericalCode.aspx

## Security
I did not put any security on the API - this needs setting up before releasing to production. 
