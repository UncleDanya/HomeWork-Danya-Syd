Feature: ActionsOnTheUserAccountPage

Background: Pre-condition
	Given User go to 'https://ek.ua/'

@mytag @deleteUser
Scenario: SaveListProductsInBookmarks
    Given User create new user account
	When User choose category 'Аудио' and type of product 'Наушники'
	When User select brand 'Logitech' by filter
	Then Verify needed checkbox with brand 'Logitech' is selected
	When User click on linked text 'Показать'
    When User save all product on page in list
	When User added product in list
    When User click on type button 'submit'
    When User switch to next page
    When User click on tabs in user page 'Наушники Logitech'
    Then Verify list save in product page for list in user page
 
@deleteUser
Scenario: SavingTheViewedProduct
    Given User create new user account
	When User choose category 'Аудио' and type of product 'Наушники'
	When User select brand 'Apple' by filter
	Then Verify needed checkbox with brand 'Apple' is selected
	When User click on linked text 'Показать'
	When User remember name product 'Apple AirPods Pro'
	When User click on linked text 'Apple AirPods Pro'
	When User choose category 'Компьютеры' and type of product 'Приставки'
	When User select brand 'Sony' by filter
	Then Verify needed checkbox with brand 'Sony' is selected
	When User click on linked text 'Показать'
	When User remember name product 'Sony PlayStation 5'
	When User click on linked text 'Sony PlayStation 5'
	When User choose category 'Аудио' and type of product 'Наушники'
	When User select brand 'Logitech' by filter
	Then Verify needed checkbox with brand 'Logitech' is selected
	When User click on linked text 'Показать'
	When User remember name product 'Logitech G Pro X'
	When User click on linked text 'Logitech G Pro X'
    When User switch to next page
    Then Verify saved list product for list product in user page