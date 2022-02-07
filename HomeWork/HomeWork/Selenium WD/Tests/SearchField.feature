Feature: SearchField

Background: Pre-condition
	Given User go to 'https://ek.ua/'

@mytag
Scenario: InputProductNameInSearchField
    When User input name product in search field 'iPhone 13 Pro', 'Найти'
    Then Verify item for searching 'iPhone 13 Pro'