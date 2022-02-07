Feature: UserAccount

Background: Pre-condition
	Given User go to 'https://ek.ua/'

@mytag @deleteUser
Scenario: RegistrationNewUserAccount
    Given User create new user account
    Then Verify account login equal expected

@deleteUser
Scenario: RenameUserAccount
    Given User create new user account
    When User click actual login
    When User click button icon 'Редактировать'
    When User clear input with header 'Ваш ник'
    When User set text input with header 'Ваш ник' , 'User123'
    When User click on button with text 'СОХРАНИТЬ'
    Then Verify actual login after rename 'User123'