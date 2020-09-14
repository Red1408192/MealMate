import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService';

export class Home extends Component {
  static displayName = Home.name;
    constructor(props) {
        super(props);
        this.state = { Token: "" };
    }
    componentDidMount() {
        this.getToken();
    }

  render () {
    return (
      <div>
        <h1>Hello, world!</h1>
            <p>Your Token Is:</p>
            <p>{this.state.Token}</p>
       </div>
    );
  }

    async getToken() {
        const token = await authService.getAccessToken();
        this.setState({ Token: token });
    }
}
