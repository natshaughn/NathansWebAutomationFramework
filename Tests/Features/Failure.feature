Feature: Failure

Expected failure test to ensure framework is working as intended

@Failure
Scenario: Fail Test
	Given I am on the login page
	When I enter the username 'standard_user'
	And I enter the password 'secret_saucessssss'
	And I click the login button
	Then I am on the inventory page 
