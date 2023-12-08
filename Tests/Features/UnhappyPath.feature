Feature: UnhappyPath

As a customer of SwagLabs, I want to see an error message if I enter incorrect details

Scenario: Enter incorrect log in details
	Given I am on the login page
	When I enter the username 'HelloWorld'
	And I enter the password 'HelloWorld123'
	And I click the login button
	Then an error message should appear
