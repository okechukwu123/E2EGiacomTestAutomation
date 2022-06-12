Feature: LogOut
As a user I want to be able to logout.
Background:
	Given I open The login page
	When I enter valid login credentials
	Then I see landing page

@ClearEnv
Scenario:As a user I want to be able to log out
	When I click logout button
	Then I  see "Login Page"
	But I cannot reach landing page without login