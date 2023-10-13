The style guidelines. 
========


# Intro #
This guide will serve as a living illustration of best practices for C# testing.

We accept that this is a live document created by fallible humans for fallible humans. Simply put, nothing is ever perfect.
But if we let our team reiterate on this example, we can get pretty darn near to the asymptote of perfection.

This document will require to be periodically editing when new or better practices become evident.
It is expected that the content is kept under source control

It ought to only remain around as long as it is still beneficial, and updated as necessary.   

If you discover something clearly wrong, simply update it. If you notice something, that is perhaps incorrect. Let's discuss and get updated as a team.  

If you encounter something in between and are unsure of what to do.
Have the default setting to update.  It is likely that you have correctly diagnosed a problem, even if. you have not correctly. prescribed this solution.  Therefore making a change and bringing it to conversation is superior than leaving it alone. 


# Inspiration #

Most of the ideas repeated here are originally from two books. Test-Driven Development and Unit Testing Principles Practices and Patterns. 

Kent Beck's book Test-Driven Development Is one of the first books defining the process of Test Driven Development or TDD for short. What is a rather short book And explains the process beautifully with examples in both C# and Java. 

Vladimir Khorikov Book Unit Testing Principles Practices and Patterns It's a much more practical book explaining. improved. ways of writing unit tests.   It's advice. doesn't contradict Kent back, but more elaborates on. Why we do certain things. 

# Guidelines #

## What are Guidelines? ##

Please note that guidelines is These are not rules these are not laws. Guidelines are For the benefit of the developer both reading and writing code. It is possible that team members will run into situations  Where the guidelines are not helpful To the reader or to the writer of the code In such situations Judge, use your own judgment on. what do you think is right? Maybe confer with colleagues? but don't let the guideline be a blocker to prevent you from moving forward. The guidelines serve the developers. The developers do not serve the guidelines.   


## AAA Pattern ## 

The AAA pattern advocates for splitting each test into three parts: arrange, act, and assert. (This pattern is sometimes also called the 3A pattern.) 

``` csharp
public class Calculator
{
    public double Sum(double first, double second)
    {
        return first + second;
    }
}
```


``` csharp
public class Calculator
{
    public double Sum(double first, double second)
    {
        return first + second;
    }
}
```




# Resources #
[Markdown Cheatsheet](https://github.com/tchapi/markdown-cheatsheet/blob/master/README.md)

# Books 
[Test-Driven Development](https://www.amazon.com/Test-Driven-Development-Kent-Beck/dp/0321146530)
[Unit Testing Principles Practices and Patterns](https://www.manning.com/books/unit-testing)