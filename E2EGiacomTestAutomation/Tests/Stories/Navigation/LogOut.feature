Feature: LogOut
Background:
	Given I open The Internet page
	When I enter valid login credentials
	Then I see landing page

@ClearEnv
Scenario: User log out
	When I click logout button
	Then I  see "Login Page"
	But I cannot reach landing page without login