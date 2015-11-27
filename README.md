FactoryAlien - A fake data generator for .Net.
===

Travis:   [![Travis](https://travis-ci.org/aspnet/Mvc.svg?branch=dev)](https://travis-ci.org/aspnet/Mvc)  

## Project Description ##
Generate fake data to improve yout unit tests.
FactoryAlien is a package inspired by factory_girl gem to help you to creating fake data to your tests.

## Overview ##
Factoryalien is designed to make test-driven development more productive and unit tests more refactoring-safe.

## Getting Started ##
Install FactoryAlien with NuGet Package Manager:
> Install-Package FactoryAlien

To start creating fake data to your tests, you just need to create a factory object with generic type to will be generated.
```csharp
IFactory<User> userFactory = FactoryAlien.Define<User>();
```

### 1. Create a single object.
To create a single fake object, use CreateOne() method.
```csharp
User user = userFactory.CreateOne();
```

So you can specify your custom values! Do following:
```csharp
User user = userFactory.CreateOne(user => {
    user.FirstName = "Gabriel";
});
```
This code will create a new User instance with "Gabriel" value in FirstName property, 
and random values in others properties.

### 2. Create an object list.
To create a fake object list, use CreateList(size) method.
```csharp
var userList = userFactory.CreateList(3);
```
This code will create a list with 3 fake objects.

You can specify your custom values when creating lists too! Do following:
```csharp
var userList = userFactory.CreateList(3, user => {
    user.FirstName = "Gabriel";
});
```
This code will create a list with 3 fake User instances with "Gabriel" value in FirstName property, 
and random values in others properties.

### 3. Building complex lists.
You can use fluent interface to create a more complex list with random and customized values, see:
```csharp
var factory = FactoryAlien.Define<Product>();
var fakeProducts = factory.CreateList(5, product => product.Category = "GAMES");
fakeProducts.Add(4)
             .Add(3, product => product.Value = 25.00)
             .Add(2, product => {
				 product.Status = "In Stock";
				 product.Category = "Computer";
			  });
```
This code above will create a list with 14 products:  
5 products with category equals to "Games";  
4 products with all properties filled with random values;  
3 products with value equals to 25.00;  
2 products with Status equals to "In Stock" and Category equals to "Computer";  
