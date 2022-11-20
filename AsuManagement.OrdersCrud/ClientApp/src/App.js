import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Order } from './components/Order';
import { OrderForm } from './components/OrderForm';
import { OrderItem } from './components/OrderItem';
import { OrderItemForm } from './components/OrderItemForm';

import './custom.css'

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home} />
                <Route path='/order' component={Order} />
                <Route path='/orderform' component={OrderForm} />
                <Route path='/orderitem' component={OrderItem} />
                <Route path='/orderitemform' component={OrderItemForm} />
            </Layout>
        );
    }
}
