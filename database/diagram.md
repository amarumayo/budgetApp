# Budget Database Diagram

This diagram shows how the core tables in the Budget application relate to each other.

```
┌──────────────────────────┐
│        Accounts          │
├──────────────────────────┤
│ Id (PK)                  │
│ Name                     │
│ Type                     │
│ StartingBalance          │
│ CreatedAt                │
└───────────────┬──────────┘
                │ 1
                │
                │ ∞
┌───────────────▼──────────┐
│       Transactions        │
├──────────────────────────┤
│ Id (PK)                  │
│ AccountId (FK → Accounts)│
│ CategoryId (FK → Categories)
│ Amount                   │
│ Date                     │
│ Description              │
│ CreatedAt                │
└───────────────┬──────────┘
                │ ∞
                │
                │ 1
┌───────────────▼──────────┐
│        Categories         │
├──────────────────────────┤
│ Id (PK)                  │
│ Name                     │
│ Type (Income/Expense)    │
│ ParentCategoryId (FK → Categories.Id)
└───────────────┬──────────┘
                │ 1
                │
                │ ∞
┌───────────────▼──────────┐
│          Budgets          │
├──────────────────────────┤
│ Id (PK)                  │
│ CategoryId (FK → Categories)
│ Amount                   │
│ Month                    │
│ Year                     │
└──────────────────────────┘
```

## Relationship Summary

### Accounts → Transactions  
- One account can have many transactions  
- `Transactions.AccountId` → `Accounts.Id`

### Categories → Transactions  
- One category can have many transactions  
- `Transactions.CategoryId` → `Categories.Id`

### Categories → Categories (self‑reference)  
- Optional parent/child hierarchy  
- `Categories.ParentCategoryId` → `Categories.Id`

### Categories → Budgets  
- One category can have many monthly budgets  
- `Budgets.CategoryId` → `Categories.Id`
