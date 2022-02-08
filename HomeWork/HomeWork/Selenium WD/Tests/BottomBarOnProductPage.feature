Feature: BottomBarOnProductPage

Background: Pre-condition
	Given User go to 'https://ek.ua/'

Scenario: AddedItemToBookmarks
	When User choose category 'Гаджеты' and type of product 'Мобильные'
	When User select brand 'Apple' by filter
	Then Verify checkbox with brand 'Apple' is selected
	When User click on linked text 'Показать'
	When User remember name product 'Apple iPhone 13'
	When User click on linked text 'Apple iPhone 13'
	When User add product in list
	When User navigate to 'Закладки' folder on bottom bar
	Then Verify that product name in bookmarks menu equals to actual product name for mobile devices

Scenario: AddedTwoItemsToCompare
	When User choose category 'Компьютеры' and type of product 'Планшеты'
    When User select brand 'Apple' by filter
    Then Verify checkbox with brand 'Apple' is selected
    When User click on linked text 'Показать'
    When User remember name product 'Apple iPad'
    When User click on linked text 'Apple iPad'
    When User click on checkbox 'добавить в сравнение'
    When User click on linked text 'Apple'
    When User remember name product 'Apple iPad Air'
    When User click on linked text 'Apple iPad Air'
    When User click on checkbox 'добавить в сравнение'
    When User navigate to 'Сравнить' folder on bottom bar
    When User switch to second page
    Then Verify product name 'Apple iPad 2021' equal the product name in comparison 'Apple iPad Air 2020'