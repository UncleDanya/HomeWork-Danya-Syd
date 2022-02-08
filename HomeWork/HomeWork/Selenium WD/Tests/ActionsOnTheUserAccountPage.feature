Feature: ActionsOnTheUserAccountPage

Background: Pre-condition
	Given User go to 'https://ek.ua/'

@mytag @deleteUser
Scenario: SaveListProductsInBookmarks
    Given User create new user account
	When User choose category 'Аудио' and type of product 'Наушники'
	When User select brand 'Logitech' by filter
	Then Verify checkbox with brand 'Logitech' is selected
	When User click on linked text 'Показать'
    When User save all product on page in list
	When User add product in list
    When User click on button with type 'submit'
    When User go to profile
    When User click on tabs in user page 'Наушники Logitech'
    Then Verify list of product names matches the list of product names in bookmarks in profile
 
@deleteUser
Scenario: SavingTheViewedProduct
    Given User create new user account
	When User choose category 'Аудио' and type of product 'Наушники'
	When User select brand 'Apple' by filter
	Then Verify checkbox with brand 'Apple' is selected
	When User click on linked text 'Показать'
	When User remember name product 'Apple AirPods Pro'
	When User click on linked text 'Apple AirPods Pro'
	When User choose category 'Компьютеры' and type of product 'Приставки'
	When User select brand 'Sony' by filter
	Then Verify checkbox with brand 'Sony' is selected
	When User click on linked text 'Показать'
	When User remember name product 'Sony PlayStation 5'
	When User click on linked text 'Sony PlayStation 5'
	When User choose category 'Аудио' and type of product 'Наушники'
	When User select brand 'Logitech' by filter
	Then Verify checkbox with brand 'Logitech' is selected
	When User click on linked text 'Показать'
	When User remember name product 'Logitech G Pro X'
	When User click on linked text 'Logitech G Pro X'
    When User go to profile
    Then Verify names viewed products matches the names in the viewed products in profile