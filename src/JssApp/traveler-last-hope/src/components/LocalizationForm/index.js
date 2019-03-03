// External modules
import React from 'react';
import { NavLink } from 'react-router-dom';
import { RichText } from '@sitecore-jss/sitecore-jss-react';
import Select from 'react-select';
import axios from 'axios';

// Shared components
import PlaceholderComponent from '../../shared/Component/ComponentPlaceholder';

// Partials of component
import './styles.scss';
import { default  as DATA } from './data.js';

const API_SEND_LOCALIZATION = 'http://sxa.test.sc/tig/weather/form';

class LocalizationForm extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      isLoading: false,
      showMessage: false,
      response: {},
      selectedOption: {
        country: {},
        city: {}
      },
      data: {
        countries: [],
        cities: []
      }
    };

    this.data = DATA.localizations;
    this.countriesData = [];
    this.data.forEach((item) => {
      this.countriesData.push({
        value: item.country,
        label: item.countryDisplayName
      });
    });

    this.handleChangeCountry = this.handleChangeCountry.bind(this);
    this.handleChangeCity = this.handleChangeCity.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  componentDidUpdate(prevState) {
    console.log('test', prevState);
  }

  handleChangeCountry(selectedData) {
    const citiesData = [];
    const getCititesData = this.data.find((item) => {
      if (item.country === selectedData.value) {
        return item;
      }
    });
    getCititesData.cities.forEach((item) => {
      citiesData.push({
        value: item,
        label: item
      });
    });

    this.setState({
      selectedOption: {
        country: selectedData.value,
        city: {}
      },
      data: {
        countries: this.data,
        cities: citiesData
      }
    });
  }

  handleChangeCity(selectedData) {
    this.setState({
      selectedOption: {
        city: selectedData.value,
        country: this.state.selectedOption.country
      }
    });
  }

  handleSubmit(event) {
    event.preventDefault();
    this.setState({
      isLoading: true
    });
    console.log(this)

    axios({
      method: 'post',
      url: API_SEND_LOCALIZATION,
      params: {
        country: this.state.selectedOption.country,
        city: this.state.selectedOption.city
      },
      headers: {
        'Content-Type': 'application/x-www-form-urlencoded'
      }
    })
    .then((response) => {
      this.setState({
        isLoading: false
      });
      console.log(response);
      // handle success
      const data = response.data;

      if (response.status === 200 || response.statusText === "OK") {
        this.setState({
          showMessage: true
        });
      }
      this.setState({
        response: data
      });
    })
    .catch((error) => {
      // handle error
      console.log(error);
    })
    .then(() => {
      // always executed
    });
  }

  render() {
    const isSuccesMessage = !!(this.state.response && this.state.response.success);
    const messageClassName = isSuccesMessage ? 'message-success' : 'message-error';
    return (
      <PlaceholderComponent {...this.props}>
        <div className="c-LocalizationForm">
          { this.props.fields && this.props.fields.heading &&
            <RichText field={this.props.fields.heading} tag="h2" className="c-LocalizationForm__heading display-4"/>
          }
          { !this.state.showMessage ? (
            <form className="c-LocalizationForm__form" onSubmit={this.handleSubmit}>
              <div className="c-LocalizationForm__form__field">
                <span className="c-LocalizationForm__form__label bg-dark">Choose your country</span>
                <Select
                  // defaultInputValue="Please choose your country"
                  options={this.countriesData}
                  onChange={this.handleChangeCountry}
                />
              </div>
              <div className="c-LocalizationForm__form__field">
                <span className="c-LocalizationForm__form__label bg-dark">Choose your city</span>
                <Select
                  // defaultInputValue="Please choose your city"
                  options={this.state.data.cities}
                  onChange={this.handleChangeCity}
                />
              </div>
              <button type="submit" className="btn btn-block btn-lg btn-success">Show weather for your location</button>
              {
                this.state.isLoading &&
                <p>Loading...</p>
              }
            </form>
          ) : (
            <div id="message" className={messageClassName}>
              <p className="text-center text-info">{this.state.response.message}</p>
              { isSuccesMessage &&
                <NavLink to="/weather-page" className="btn btn-block btn-lg btn-success">Go to weather page</NavLink>
              }
            </div>
          )}
        </div>
      </PlaceholderComponent>
    );
  }
}

export default LocalizationForm;
