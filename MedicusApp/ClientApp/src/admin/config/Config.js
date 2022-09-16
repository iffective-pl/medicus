import config from './config.json';

const Config = !process.env.NODE_ENV || process.env.NODE_ENV === 'development' ? config.dev : config.prod;

export default Config;