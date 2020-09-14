import React, { Component, useRef, Fragment } from 'react';
//import { Button } from 'react-bootstrap';
//import Select from 'react-select';
import JoditEditor from "jodit-react";
import authService from './api-authorization/AuthorizeService'

export class IngredientForm extends Component {



    constructor(props) {
        super(props);
        this.state = {
            ParentIngredients: [], UnitsTypes: [], producers: [], loading: true,
            parentId: null,
            name: "",
            descShort: "",
            descLong: "",
            submited: false,
            value: '',
            setValue: '',
            //Ingredient detail
            hasDetail: true,
            AverageLifeTime: null,
            unitType: 3,
            specificWheight: null,
            water: 0,
            protein: 0,
            fatTotal: 0,
            fatSaturated: 0,
            fatUnsaturatedMono: 0,
            fatUnsaturatedPoli: 0,
            cholesterol: 0,
            carbohydrate: 0,
            fiber: 0,
            calcium: 0,
            iron: 0,
            potasium: 0,
            sodium: 0,
            vitA_IU: 0,
            vitA_RE: 0,
            vitB_1: 0,
            vitB_2: 0,
            vitB_3: 0,
            vitC: 0,
            //Producer
            isProduct:0,
            producerId: 1,
            Unitype: 3,
            quantity: 0,
            token: ""
        };
    }

    componentDidMount() {
        this.GetAuthorization()
        this.GetIngredientNames()
        this.GetUniteTypesNames()
        this.GetProducers()
    }

    generateOptionListParents(parentList) {
        return parentList.map(el =>
            <option value={el.ingId}>{el.name}</option>)
    }

    generateOptionListUnits(unitList) {
        return unitList.map(el =>
            <option value={el.UnitId}>{el.UnitName}</option>)
    }

    generateOptionProducer(prodList) {
        return prodList.map(el =>
            <option value={el.BrandId}>{el.BrandName}</option>)
    }

    render() {
        return (
            <Fragment>
                <div className="main tab" style={{ float: "left", width: "600px" }}>
                    <legend>Main</legend>
                    <div className="input main">
                        <label className="formlabel">Parent Ingredient</label>
                        <div></div>
                        <select value={this.state.parentId} onChange={e => this.setState({ parentId: e.target.value })}>
                            {this.generateOptionListParents(this.state.ParentIngredients)}
                        </select>
                    </div>
                    <div className="input main">
                        <label className="formlabel">Name</label>
                        <div></div>
                        <input type="text" value={this.state.name} onChange={e => this.setState({ name: e.target.value })} />
                    </div>
                    <div className="input main">
                        <label className="formlabel">Description Short</label>
                        <div></div>
                        <textarea name="body" onChange={e => this.setState({ descShort: e.target.value })} value={this.state.descShort} />
                    </div>
                    <div className="input main">
                        <label className="formlabel">Description Long</label>
                        <div></div>
                        <JoditEditor
                            //ref={useRef(null)}
                            value={this.state.descLong}
                            config={{
                                readonly: false,
                                toolbarAdaptive: false,
                                toolbarButtonSize: "small",
                                height: 500,
                                buttons: ['bold', 'strikethrough', 'underline', 'italic', '|', 'superscript', 'subscript', 'ul', 'ol', '\n', 'outdent', 'indent', 'fontsize', 'align', 'image', 'link', '|', 'undo', 'redo']}}
                            tabIndex={1} // tabIndex of textarea
                            onBlur={e => this.setState({ descLong: e })} // preferred to use only this option to update the content for performance reasons
                            //onChange={e => this.setState({ descLong: e.value })}
                        />
                    </div>
                    <hr className="separator" style={{ height: "60px" }} />
                    </div>
                <hr className="separator" style={{ float: "left", height: "800px", margin: "30px" }} />
                <div className="detail tab" style={{ float: "left", width: "200px" }}>
                    <legend>Detail</legend>
                    <input id="0001" style={{ float: "right" }} type="checkbox" checked={this.state.hasDetail} name="DetailCheck" onChange={() => this.setState({ hasDetail: !this.state.hasDetail })}/>
                    <label style={{ fontSize: "10px", float: "right", marginRight: "5px" }} htmlFor="0001">Post detail data  </label>
                    <div style={{ height: "30px" }} />
                    <div className="detail input">
                        <label className="formlabel">Unit Type</label>
                        <div></div>
                        <select disabled={!this.state.hasDetail} value={this.state.unitType} onChange={e => this.setState({ unitType: e.target.value })}>
                            {this.generateOptionListUnits(this.state.UnitsTypes)}
                        </select>
                    </div>
                    <div className="detail input">
                        <label className="formlabel">Average Life Time</label>
                        <div></div>
                        <input disabled={!this.state.hasDetail} type="number" step="1" value={this.state.AverageLifeTime} onChange={e => this.setState({ AverageLifeTime: e.target.value })} />
                    </div>
                    <div className="detail input">
                        <label className="formlabel">Specific weight</label>
                        <div></div>
                        <input disabled={!this.state.hasDetail} type="number" step="0.0001" value={this.state.specificWheight} onChange={e => this.setState({ specificWheight: e.target.value })} />
                    </div>
                    <div className="detail input">
                        <label className="formlabel">Water</label>
                        <div></div>
                        <input disabled={!this.state.hasDetail} type="number" step="0.0001" value={this.state.water} onChange={e => this.setState({ water: e.target.value })} />
                    </div>
                    <div className="detail input">
                        <label className="formlabel">Protein</label>
                        <div></div>
                        <input disabled={!this.state.hasDetail} type="number" step="0.0001" value={this.state.protein} onChange={e => this.setState({ protein: e.target.value })} />
                    </div>
                    <div className="detail input">
                        <label className="formlabel">Fat Total</label>
                        <div></div>
                        <input disabled={!this.state.hasDetail} type="number" step="0.0001" value={this.state.fatTotal} onChange={e => this.setState({ fatTotal: e.target.value })} />
                    </div>
                    <div className="detail input">
                        <label className="formlabel">Fat Saturated</label>
                        <div></div>
                        <input disabled={!this.state.hasDetail} type="number" step="0.0001" value={this.state.fatSaturated} onChange={e => this.setState({ fatSaturated: e.target.value })} />
                    </div>
                    <div className="detail input">
                        <label className="formlabel">Fat Unsaturated Mono</label>
                        <div></div>
                        <input disabled={!this.state.hasDetail} type="number" step="0.0001" value={this.state.fatUnsaturatedMono} onChange={e => this.setState({ fatUnsaturatedMono: e.target.value })} />
                    </div>
                    <div className="detail input">
                        <label className="formlabel">Fat Unsaturated Poli</label>
                        <div></div>
                        <input disabled={!this.state.hasDetail} type="number" step="0.0001" value={this.state.fatUnsaturatedPoli} onChange={e => this.setState({ fatUnsaturatedPoli: e.target.value })} />
                    </div>
                    <div className="detail input">
                        <label className="formlabel">Cholesterol</label>
                        <div></div>
                        <input disabled={!this.state.hasDetail} type="number" step="0.0001" value={this.state.cholesterol} onChange={e => this.setState({ cholesterol: e.target.value })} />
                    </div>
                    <div className="detail input">
                        <label className="formlabel">Carbohydrate</label>
                        <div></div>
                        <input disabled={!this.state.hasDetail} type="number" step="0.0001" value={this.state.carbohydrate} onChange={e => this.setState({ carbohydrate: e.target.value })} />
                    </div>
                    <div className="detail input">
                        <label className="formlabel">Fiber</label>
                        <div></div>
                        <input disabled={!this.state.hasDetail} type="number" step="0.0001" value={this.state.fiber} onChange={e => this.setState({ fiber: e.target.value })} />
                    </div>
                    <div className="detail input">
                        <label className="formlabel">Calcium</label>
                        <div></div>
                        <input disabled={!this.state.hasDetail} type="number" step="0.0001" value={this.state.calcium} onChange={e => this.setState({ calcium: e.target.value })} />
                    </div>
                    <div className="detail input">
                        <label className="formlabel">Iron</label>
                        <div></div>
                        <input disabled={!this.state.hasDetail} type="number" step="0.0001" value={this.state.iron} onChange={e => this.setState({ iron: e.target.value })} />
                    </div>
                    <div className="detail input">
                        <label className="formlabel">Potasium</label>
                        <div></div>
                        <input disabled={!this.state.hasDetail} type="number" step="0.0001" value={this.state.potasium} onChange={e => this.setState({ potasium: e.target.value })} />
                    </div>
                    <div className="detail input">
                        <label className="formlabel">Sodium</label>
                        <div></div>
                        <input disabled={!this.state.hasDetail} type="number" step="0.0001" value={this.state.sodium} onChange={e => this.setState({ sodium: e.target.value })} />
                    </div>
                    <div className="detail input">
                        <label className="formlabel">Vit A RE(retinol equivalent)</label>
                        <div></div>
                        <input disabled={!this.state.hasDetail} type="number" step="0.0001" value={this.state.vitA_RE} onChange={e => this.setState({ vitA_RE: e.target.value })} />
                    </div>
                    <div className="detail input">
                        <label className="formlabel">Vit A IU(international unit)</label>
                        <div></div>
                        <input disabled={!this.state.hasDetail} type="number" step="0.0001" value={this.state.vitA_IU} onChange={e => this.setState({ vitA_IU: e.target.value })} />
                    </div>
                    <div className="detail input">
                        <label className="formlabel">Vit B1</label>
                        <div></div>
                        <input disabled={!this.state.hasDetail} type="number" step="0.0001" value={this.state.vitB_1} onChange={e => this.setState({ vitB_1: e.target.value })} />
                    </div>
                    <div className="detail input">
                        <label className="formlabel">Vit B2</label>
                        <div></div>
                        <input disabled={!this.state.hasDetail} type="number" step="0.0001" value={this.state.vitB_2} onChange={e => this.setState({ vitB_2: e.target.value })} />
                    </div>
                    <div className="detail input">
                        <label className="formlabel">Vit B3</label>
                        <div></div>
                        <input disabled={!this.state.hasDetail} type="number" step="0.0001" value={this.state.vitB_3} onChange={e => this.setState({ vitB_3: e.target.value })} />
                    </div>
                    <div className="detail input">
                        <label className="formlabel">Vit C</label>
                        <div></div>
                        <input disabled={!this.state.hasDetail} type="number" step="0.0001" value={this.state.vitC} onChange={e => this.setState({ vitC: e.target.value })} />
                    </div>
                    <hr className="separator" style={{ height: "60px" }} />
                </div>
                <hr className="separator" style={{ float: "left", height: "800px", margin: "30px" }} />
                <div className="product tab" style={{ float: "left" }}>
                    <legend>Product Data</legend>
                    <input style={{ float: "right" }} type="checkbox" checked={this.state.isProduct} name="ProductCheck" onChange={() => this.setState({ isProduct: !this.state.isProduct })} id="0002" />
                    <label style={{ fontSize: "10px", float: "right", marginRight:"5px" }} htmlFor="0002">Post product data  </label>
                    <div style={{ height: "30px" }}/>
                    <div className="Product input">
                        <div>
                            <label className="Product input">Producer</label>
                            <div></div>
                            <select disabled={!this.state.isProduct} value={this.state.producerId} onChange={e => this.setState({ producerId: e.target.value })}>
                                {this.generateOptionProducer(this.state.producers)}
                            </select>
                        </div>
                        <div className="Product input">
                            <label className="formlabel">Unit Type</label>
                            <div></div>
                            <select disabled={!this.state.isProduct} value={this.state.unitType} onChange={e => this.setState({ unitType: e.target.value })}>
                                {this.generateOptionListUnits(this.state.UnitsTypes)}
                            </select>
                        </div>
                        <div className="Product input">
                            <label className="formlabel">Quantity</label>
                            <div></div>
                            <input disabled={!this.state.isProduct} type="number" step="0.0001" value={this.state.quantity} onChange={e => this.setState({ quantity: e.target.value })} />
                        </div>
                    </div>
                </div>
                <div className="submitButton" style={{ float: "left", margin: "35px" }}>
                    <button onClick={() => this.PostNewIngredient()}>Submit</button>
                </div>
            </Fragment>
        );
    }
    async GetAuthorization() {
        let tok = await authService.getAccessToken();
        this.setState({ token: tok });
    }
    async GetIngredientNames() {
        let response = await fetch('Ingredient/GetList/1', {
            headers: !this.token ? {} : { 'Authorization': `Bearer ${this.state.token}` }
        });
        let data = await response.json();
        this.setState({ ParentIngredients: data });
    }
    async GetUniteTypesNames() {
        let response = await fetch('Unit/GetAll/', {
            headers: !this.token ? {} : { 'Authorization': `Bearer ${this.state.token}` }
        });
        let data = await response.json();
        this.setState({ UnitsTypes: data });
    }
    async GetProducers() {
        let response = await fetch('Producer/GetList/', {
            headers: !this.token ? {} : { 'Authorization': `Bearer ${this.state.token}` }
        });
        let data = await response.json();
        this.setState({ producers: data, loading: false });
    }
    async PostNewIngredient() {
        let IngredientPackage = {
            main: {
                parentId: this.state.parentId,
                ingredientId:0,
                language: 1,
                name: this.state.name,
                descShort: this.state.descShort,
                descLong: this.state.descLong,
            },
            detail: null,
            product: null
        }
        if (this.state.hasDetail) {
            IngredientPackage.detail = {
                averageLifeTime: this.state.AverageLifeTime,
                uType: this.state.unitType,
                specificWheight: this.state.specificWheight,
                water: this.state.water,
                protein: this.state.protein,
                fatTotal: this.state.fatTotal,
                fatUnsaturatedMono: this.state.fatUnsaturatedMono,
                fatUnsaturatedPoli: this.state.fatUnsaturatedPoli,
                cholesterol: this.state.cholesterol,
                carbohydrate: this.state.carbohydrate,
                fiber: this.state.fiber,
                calcium: this.state.calcium,
                iron: this.state.iron,
                potasium: this.state.potasium,
                sodium: this.state.sodium,
                vitA_IU: this.state.vitA_IU,
                vitA_RE: this.state.vitA_RE,
                vitB_1: this.state.vitB_1,
                vitB_2: this.state.vitB_2,
                vitB_3: this.state.vitB_3,
                vitC: this.state.vitC,
            }
        }
        if (this.state.isProduct) {
            IngredientPackage.product = {
                producerId: this.state.producerId,
                unitType: this.state.unitType,
                quantity: this.state.quantity,
            }
        }
        let json = JSON.stringify(IngredientPackage)
        fetch('Ingredient/Post/', {
            method: 'POST',
            body: json,
            headers: {
                'Content-Type': 'application/json'
            }
        })
        window.location.reload(false);
    }
}