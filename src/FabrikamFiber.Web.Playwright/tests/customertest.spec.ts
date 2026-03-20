import { test, expect } from "@playwright/test";

test.describe('Demo test.', () => {
  test('basic test', {tag: '@smoke',}, async ({ page }) => {
    await page.goto('/');

    await page.getByText("Customers").click();

    await expect(page.locator(".dataTable")).toBeVisible();

    const oldRowCount = await page.locator(".dataTable").locator("tr").count();

    await page.getByText("Create New").click();
    await page.locator("#FirstName").fill("Fred");
    await page.locator("#LastName").fill("Bloggs");
    await page.locator("#Address_Street").fill("1 The Road");
    await page.locator("#Address_City").fill("Townsville");
    await page.locator("#Address_State").fill("Countyshire");
    await page.locator("#Address_Zip").fill("12345");
    await page.locator("input[type='submit'][value='Create']").click();

    await expect(page.locator(".dataTable")).toBeVisible();

    const newRowCount = await page.locator(".dataTable").locator("tr").count();

    expect(newRowCount - oldRowCount).toBe(1);
  });
});

