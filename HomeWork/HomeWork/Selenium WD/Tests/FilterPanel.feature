Feature: FilterPanel

Background: Pre-condition
	Given User go to 'https://ek.ua/'

Scenario: FilterProductsByBrand
	When User choose category 'Компьютеры' and type of product 'Ноутбуки'
    When User select brand 'Acer' by filter
    Then Verify checkbox with brand 'Acer' is selected
    When User click on linked text 'Показать'
    Then Verify filter show actual brand 'Acer'