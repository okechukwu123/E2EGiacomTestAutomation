Feature: User login
  As site user
  I want to be able to log in
  In order to see landing page

Background:
	Given I open The Internet page

@ClearEnv
Scenario: User log in with valid credentials
	Given I open The Internet page
	When I enter valid login credentials
	Then I see landing page


