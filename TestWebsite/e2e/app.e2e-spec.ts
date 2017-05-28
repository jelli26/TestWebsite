import { Angular4TestAppPage } from './app.po';

describe('angular4-test-app App', () => {
  let page: Angular4TestAppPage;

  beforeEach(() => {
    page = new Angular4TestAppPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
