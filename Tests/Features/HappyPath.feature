﻿Feature: HappyPath

As a customer of SwagLabs I want to be able to buy a product with no issues

Scenario: Purchase a single item
    Given I have logged in
    When I add 'sauce-labs-backpack' to cart
    And I complete the checkout process
    Then a message will appear confirming my order