Feature: SwitchToShopWithProduct

Background: Pre-condition
	Given User go to 'https://ek.ua/'

Scenario: ThroughTheProductSwitchToShop
	When User choose category 'Гаджеты' and type of product 'Мобильные'
    When User select brand 'Apple' by filter
    Then Verify checkbox with brand 'Apple' is selected
    When User click on linked text 'Показать'
    When User remember product name 'Apple iPhone 13'
    When User click on linked text 'Apple iPhone 13'
    When User click on linked text 'Avic.ua'
    When User switch to second page
    Then Verify that product name in other shop equals to actual product name for mobile devices