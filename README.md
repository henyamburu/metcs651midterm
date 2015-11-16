Client-browser/Server Decoder
=============================
A client/server web solution that enables a user to enter a secret message and try out
various character substitution strategies based on letter, bigram, and trigram frequency
tables.

User is able to overide the default strategy follow the strategies:

- `Character`, is the analysis of letters frequency occuring in text and substituting with
relatively frequent letters. 
- `Bigram`, the sequence of two adjacent letters in a string of tokens that are n-grams for n=2 
in frequent distribution of bigrams for simple statistical analysis of text 
- `Triagram`, sequence of three adjacent letters in a string of tokens that are n-grams for n=3
- `Gold-bug`, substitution cipher replacing letter with symbols.

Web\default.aspx
================
The Web page reads in lines decoded text entered by users, applies one of the strategies indicated
above, and calls on web service to decode message.  The resulting decoded text is printed on a 
paragraph element.

As User enters or changes the text and/or selects a strategy, the decoded message is dynamically
rendered on the page.

- `jQuery library`, is call on to facilitate with dynamic functions in extracting value from html
controls and making AJAX request to the web service.
- `Web/Service.svc`, is the server-side code that serves class and method functionality to be
consumed by AJAX asynchronously. 
