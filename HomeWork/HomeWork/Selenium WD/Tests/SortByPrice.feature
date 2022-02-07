Feature: SortByPrice

Background: Pre-condition
	Given User go to 'https://ek.ua/'

@mytag
Scenario: PriceSortingInAscending
    When User choose category 'Гаджеты' and type of product 'Мобильные'
	When User select brand 'Apple' by filter
	Then Verify needed checkbox with brand 'Apple' is selected
	When User click on linked text 'Показать'
    When User click on linked text 'Apple iPhone 13 Pro'
    When User click on linked text 'Cравнить цены'
    When User click on linked text 'по цене'
    Then Verify each next price is greater than or equal to the previous one