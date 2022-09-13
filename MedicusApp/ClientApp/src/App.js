import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import Base from "./base/Base";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Base>
        <Routes>
          {AppRoutes.map((route, index) => {
            const { element, path, optional } = route;
            return (
              <Route key={index} path={path} element={element}>
                {optional ? optional.map((item, key) =>
                  <Route key={key} path={item.path} element={item.element}/>
                ) : null}
              </Route>
            );
          })}
        </Routes>
      </Base>
    );
  }
}
