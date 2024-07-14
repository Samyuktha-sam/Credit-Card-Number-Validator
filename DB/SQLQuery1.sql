USE [CreditCardValidation]
GO

SELECT [CardTypeID]
      ,[CardTypeName]
      ,[Prefix]
      ,[Length]
  FROM [dbo].[CardTypes]

GO

SELECT [RequestID]
      ,[CreditCardNumber]
      ,[IsValid]
      ,[CardType]
      ,[Timestamp]
  FROM [dbo].[ValidationRequests]

GO

