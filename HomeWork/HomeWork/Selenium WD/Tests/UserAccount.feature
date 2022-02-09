Feature: UserAccount

Background: Pre-condition
	Given User go to 'https://ek.ua/'

@deleteUser
Scenario: RegistrationNewUserAccount
	Given User create new user account
	Then Verify actual login equal random login entered

@deleteUser
Scenario: RenameUserAccount
	Given User create new user account
	When User go to profile
	When User click button icon 'Редактировать'
	When User clear input with header 'Ваш ник'
	When User set text input with header 'Ваш ник' , 'User123'
	When User click on button with text 'СОХРАНИТЬ'
	Then Verify actual login equal the changed random login 'User123'