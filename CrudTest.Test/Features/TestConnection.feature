Feature: TestConnection

    I want to test connecting to my API
    So that I can ensure API communication works

Scenario: Test connecting to my API endpoint
    When I call the API endpoint
    Then the response status code should be OK
