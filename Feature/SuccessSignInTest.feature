Feature: SuccessSignInTest
	Success in access app Smart Hotel 360 

@mytag
Scenario: SuccessSignInTest
	Given I check the SmatHotel360 app is installed in my device
	And I entered with "username"
	And I entered with "password"
	When I click in "signin" button
	Then the result should be the screen "message" 
