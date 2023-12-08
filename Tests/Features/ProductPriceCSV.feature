Feature: ProductPriceCSV

A short summary of the feature

@DataSource:SauceLabsPriceList.csv
Scenario: Using .csv file to confirm product prices
	Given I have logged in
	Then the <price> of the <product> will be correct