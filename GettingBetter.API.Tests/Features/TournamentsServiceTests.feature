Feature: TournamentsServiceTest
As a Coach
I want to create a new tournament
In order to promote a game.

    Background:
        Given the Endpoint https://localhost:8080/api/v1/Coaches/1/Tournaments is available

        @cyber-register
    Scenario: A coach wants to create a new Tournament 
        When a Post Request is sent
        | Title        | Description          | Date | 
        | sample title | Sample text          | today|
        Then A Response with Status 200 is received
        And a Succest message with value "Succes post" is returned
        
    @cyber-register
    Scenario: A coach wants to create with missing date
        Given Date is Null
        When a Post Request is sent
        | Title        | Description          | Date | 
        | sample title | Sample text          | Null |
        Then A Response with Status 400 is received
        And An Error Message with value "Tournament can not be created  without a date" is returned
