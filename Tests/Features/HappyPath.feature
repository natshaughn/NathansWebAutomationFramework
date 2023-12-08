Feature: HappyPath

As a customer of SwagLabs I want to be able to buy a product with no issues

Scenario: Purchase a single item
    Given I have logged in
    When I add 'sauce-labs-backpack' to cart
    And I click on the cart button 
    And I click the checkout button 
    And I enter information details 'John' 'Doe' '12345'
    And I click continue 
    And I click finish 
    Then a message will appear confirming my order
