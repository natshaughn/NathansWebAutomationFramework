Feature: ProductPriceCSV

Verify the price of the products on the page 

@DataSource:SauceLabsPriceList.csv
Scenario: Using .csv file to confirm product prices
	Given I have logged in
	When I am on the inventory page
	Then the <price> of the <product> will be correct