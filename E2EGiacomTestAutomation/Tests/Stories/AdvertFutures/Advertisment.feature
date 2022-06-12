Feature: Advertisment

As a user I want to navigate to Advertisment page and slect option 2
Background: 
	Given I open The login page
	When I enter valid login credentials
	
@ClearEnv
Scenario:Page with entry advertisement
	
	When I click on link Entry Ad
	Then I see modal Window
	And I can close modal window
	And I can select "Option 2" from dropdown menu
