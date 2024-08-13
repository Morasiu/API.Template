# Error codes

Here new application error codes can be added. For example `EmailErrorCodes` or `FileServiceErrorCodes`.

Steps to add new error code:
1. Add new `SomethingErrorCodes` class
2. Add new props in `ErrorCodes`class i.e. `public static readonly SomethingErrorCodes Something = new();`

> These codes are static so frontend can use it for their error messages.