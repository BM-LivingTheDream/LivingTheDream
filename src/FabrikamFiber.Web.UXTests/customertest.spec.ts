import { test, expect } from '@playwright/test';
import { readFileSync } from 'fs';

interface AppSettings {
  TestUrl: string;
}

function getAppSettings(): AppSettings {
  const configRaw = readFileSync('appsettings.json', 'utf-8');
  const config = JSON.parse(configRaw);
  return config.AppSettings as AppSettings;
}

test.describe('CustomerTest', () => {
  let appSettings: AppSettings;

  test.beforeEach(() => {
    appSettings = getAppSettings();
  });

  test('CanAddCustomer', async ({ page }) => {
    await page.goto(appSettings.TestUrl);

    await page.getByText('Customers').click();

    // this is needed when running tests on GHE hosted agents as they are too fast
    await expect(page.locator('.dataTable')).toBeVisible();

    const oldRowCount = await page.locator('.dataTable tr').count();

    console.log(`Pre-test row count: ${oldRowCount}`);

    await page.getByText('Create New').click();
    await page.locator('#FirstName').fill('Fred');
    await page.locator('#LastName').fill('Bloggs');
    await page.locator('#Address_Street').fill('1 The Road');
    await page.locator('#Address_City').fill('Townsville');
    await page.locator('#Address_State').fill('Countyshire');
    await page.locator('#Address_Zip').fill('12345');
    await page.locator("input[type='submit'][value='Create']").click();

    // this is needed when running tests on GHE hosted agents as they are too fast
    await expect(page.locator('.dataTable')).toBeVisible();

    const newRowCount = await page.locator('.dataTable tr').count();
    console.log(`Post-test row count: ${newRowCount}`);

    expect(newRowCount - oldRowCount).toBe(1);
  });
});
