import { test, expect } from "@playwright/test";
import playwrightConfig from '../playwright.config';

const testURL = playwrightConfig?.use?.baseURL || '';

test.describe('Demo test.', () => {
  test('basic test', {tag: '@smoke',}, async ({ page }) => {
    await page.goto('https://playwright.dev/');
    // ...
  });
});

