import { platformBrowserDynamic } from '../lib-npm/angular/platform-browser-dynamic';

import { AppModule } from "./app.module";

platformBrowserDynamic().bootstrapModule(AppModule);