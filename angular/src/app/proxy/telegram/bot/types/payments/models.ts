import type { User } from '../models';

export interface Invoice {
  title?: string;
  description?: string;
  startParameter?: string;
  currency?: string;
  totalAmount: number;
}

export interface OrderInfo {
  name?: string;
  phoneNumber?: string;
  email?: string;
  shippingAddress: ShippingAddress;
}

export interface PreCheckoutQuery {
  id?: string;
  from: User;
  currency?: string;
  totalAmount: number;
  invoicePayload?: string;
  shippingOptionId?: string;
  orderInfo: OrderInfo;
}

export interface ShippingAddress {
  countryCode?: string;
  state?: string;
  city?: string;
  streetLine1?: string;
  streetLine2?: string;
  postCode?: string;
}

export interface ShippingQuery {
  id?: string;
  from: User;
  invoicePayload?: string;
  shippingAddress: ShippingAddress;
}

export interface SuccessfulPayment {
  currency?: string;
  totalAmount: number;
  invoicePayload?: string;
  shippingOptionId?: string;
  orderInfo: OrderInfo;
  telegramPaymentChargeId?: string;
  providerPaymentChargeId?: string;
}
