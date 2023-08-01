Feature: Create Customer
    check create Customer

Scenario: Valid customer data is provided
    Given the following customer details:
        | FirstName  | LastName   | DateOfBirth | PhoneNumber    | Email                      | BankAccountNumber     |
        | Ali       | Omrani        | 1994-02-01  | +989389121376  | aliomrani5@gmail.com       | 1234567890            |
    When I create the customer
    Then the customer should be created successfully
    #And the response should indicate success with no error message

Scenario: Duplicate email is provided
    Given the following customer details:
        | FirstName  | LastName   | DateOfBirth | PhoneNumber    | Email                      | BankAccountNumber     |
        | Ali       | Omrani        | 1990-01-01  | +989389121376  | aliomrani4@gmail.com      | 1234567890            |
    When I create the customer
    Then the customer creation should fail
    #And the response should indicate failure with the error message "Invalid email format"

Scenario: Duplicate Customer Info is provided
    Given the following customer details:
        | FirstName  | LastName   | DateOfBirth | PhoneNumber    | Email                      | BankAccountNumber     |
        | Ali       | Omrani        | 1990-01-01  | +989389121376  |  aliomrani7@gmail.com      | 1234567890            |
    When I create the customer
    Then the customer creation should fail
    #And the response should indicate failure with the error message "Bank account number is required"