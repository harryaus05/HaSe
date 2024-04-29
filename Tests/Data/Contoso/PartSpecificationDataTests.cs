﻿using HaSe.Data;
using HaSe.Data.Project;
using HaSe.Tests.Helpers;

namespace HaSe.Tests.Data.Contoso;

[TestClass]
public class PartSpecificationDataTests : SealedNewTests<PartSpecificationData, EntityData> {
    [TestMethod] public void NameTest() => PropertyTest();
    [TestMethod] public void BudgetTest() => PropertyTest();
    [TestMethod] public void StartDateTest() => PropertyTest();
    [TestMethod] public void InstructorIdTest() => PropertyTest();
}